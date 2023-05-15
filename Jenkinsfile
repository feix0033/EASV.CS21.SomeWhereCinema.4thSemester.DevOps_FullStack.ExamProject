pipeline {
    agent any

    // triggers {
    //     pollSCM('* * * * *')
    // }

    environment {
        CI = 'true'
        DOTNET_ROOT = '/usr/bin/dotnet'
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
        stage('CI_UnitTest_BackEnd') {
            agent any
            when {
                branch 'BackEnd*'
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest') {
                    echo 'remove histiory test results'
                    sh 'rm -rf TestResults'
                    sh 'dotnet add package coverlet.collector'
                    sh 'dotnet test --collect:\'Xplat Code Coverage\''
                }
            }
            post {
                success {
                    archiveArtifacts 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'

                    publishCoverage adapters: 
                    [
                        istanbulCoberturaAdapter
                        (
                            path: 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml', 
                            thresholds:
                            [[
                            failUnhealthy: true,
                            thresholdTarget: 'Conditional',
                            unhealthyThreshold: 80.0, // below 80%
                            unstableThreshold: 50.0  // below 50%
                            ]]
                        )
                    ],
                    checksName: '',
                    sourceFileResolver: sourceFile('NEVER_STORE')
                }
            }
        }

        stage('CI_Build_BackEnd') {
            agent any
            when {
                branch 'BackEnd*'
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                sh 'dotnet build'
                    
                    // was the docker compose will use local image or get from docker hub?

                    // withCredentials(
                    //     [usernamePassword(
                    //         credentialsId: 'usernamepasswordMultibinding',
                    //         passwordVariable: 'PASSWORD', 
                    //         usernameVariable: 'USERNAME')])
                    // {
                    //      sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                    // }
                    // sh "docker push evensnachi/somewhere-cinema"
                }
            }
        }

        stage('CI_UnitTest_FrontEnd') {
            when {
                branch('FrontEnd*')
            }
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            steps {
                echo "Test will later......."
            }
        }

        stage('CI_Build_FrontEnd') {
            when {
                branch('FrontEnd*')
            }
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            steps {
                dir('SomeWhereCinema.Frontend') {
                    sh 'npm cache clean --force'
                    sh 'npm cache verify'
                    // sh 'npm install npm'
                    sh 'npm install'
                    sh 'npm i -g @angular/cli'
                    sh 'ng build'
                }
            }
        }

        stage("CR_MergeBranch_Main") {
            agent any
            when {
                branch ('BackEnd_Dev')
            }
            steps {
                sh "git fetch -a"
                sh "git checkout BackEnd"
                sh "git merge BackEnd_Dev"
                sh "git push"
            }
        }

        stage("CR_IntergrationTest") {
            when {
                branch('main')
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                    echo "docker setup"
                    sh "docker-compose up -d"
                    echo "Test cafe"
                }
            }
            post {
                always {
                    dir(path: 'SomeWhereCinema.Backend') {
                        sh script:"docker-compose down", returnStatus: true
                    }
                    
                }
            }
        }

        stage('CD_BackEnd_TO_DockerHub') {
            agent any
            when {
                branch 'main'
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                    sh "docker build -t evensnachi/somewhere-cinema ."
                    withCredentials(
                        [usernamePassword(
                            credentialsId: 'usernamepasswordMultibinding',
                            passwordVariable: 'PASSWORD', 
                            usernameVariable: 'USERNAME')])
                    {
                         sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                    }
                    sh "docker push evensnachi/somewhere-cinema"
                }
            }
        }

        // stage ('CD_FrontEnd_To_Firebase') {
        //     agent any
        //     when {
        //         branch 'main'
        //     }
        //     steps {
        //         dir(path: 'SomeWhereCinema.Frontend') {
        //             // could that working like this?
        //             withCredentials(
        //                 [usernamePassword(
        //                     credentialsId: 'firebase',
        //                     passwordVariable: 'PASSWORD', 
        //                     usernameVariable: 'USERNAME')])
        //             {
        //                  sh 'firebase login -u ${USERNAME} -p ${PASSWORD}'
        //             }
        //             sh "firebase deploy"
        //         }
        //     }
        // }

        stage ('CD_Performancetesting'){
            agent any
            when {
                branch 'main'
            }
            steps {
                echo 'performance test'
            }
        }
    }

    post {
        always {
            echo '====++++All stages finish++++===='
            deleteDir()
        }
        success {
            echo '====++++successfully++++===='
        }
        failure {
            echo '====++++failed++++===='
        }
    }
}