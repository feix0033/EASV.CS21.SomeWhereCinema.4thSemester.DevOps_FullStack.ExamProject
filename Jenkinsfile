pipeline {
    // agent { dockerfile true }
    agent any

    triggers {
        pollSCM('* * * * *')
    }

    environment {
        CI = 'true'
        DOTNET_ROOT = '/usr/bin/dotnet'
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
        stage('CI_UnitTest_BackEnd') {
            when {
                branch 'BackEnd*'
            }

            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:7.0'
                    args '-p 3000:3000'
                }
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

                    // publishCoverage adapters: 
                    // [
                    //     istanbulCoberturaAdapter
                    //     (
                    //         path: 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml', 
                    //         thresholds:
                    //         [[
                    //         failUnhealthy: true,
                    //         thresholdTarget: 'Conditional',
                    //         unhealthyThreshold: 80.0, // below 80%
                    //         unstableThreshold: 50.0  // below 50%
                    //         ]]
                    //     )
                    // ],
                    // checksName: '',
                    // sourceFileResolver: sourceFile('NEVER_STORE')
                }
            }
        }

        stage('CI_Build_BackEnd') {
            when {
                branch 'BackEnd*'
            }

            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:7.0'
                }
            }
            
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                sh 'dotnet build'
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

        stage('CD_BackEnd_To_DockerHub') {
            when {
                branch 'main'
            }
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                    sh 'npm -v'
                    sh "docker build -t evensnachi/somewhere-cinema ."
                    withCredentials(
                        [usernamePassword(
                            credentialsId: 'dockerHub',
                            passwordVariable: 'PASSWORD', 
                            usernameVariable: 'USERNAME')])
                    {
                         sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                    }
                    sh "docker push evensnachi/somewhere-cinema"
                }
            }
        }
        
        stage("CR_IntegrationTest") {
            when {
                branch('main')
            }
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                    sh "docker-compose up -d"
                }
                dir(path: 'SomeWhereCinema.FrontEnd'){
                    sh 'npm i testcafe'
                    
                }
                dir(path: 'SomeWhereCinema.FrontEnd') {
                    sh 'testcafe --list-browsers'
                    sh 'testcafe all E2ETest/test.ts' 
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
            when {
                branch 'main'
            }
            agent any
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
