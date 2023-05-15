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
        stage('Unit Test BackEnd') {
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

        stage('Build BackEnd') {
            agent any
            when {
                branch 'BackEnd*'
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                sh 'dotnet build'
                }
            }
        }

        stage('Deliver to Docker Hub') {
            agent any
            when {
                branch 'main'
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                    echo 'deliver to docker hub'
                    sh "docker build -t evensnachi/somewhere-cinema ."
                    withCredentials ([[$class: 'usernamepasswordMultibinding']])
                    {
                         sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                    }
                    sh "docker push evensnachi/somewhere-cinema"
                }
            }

        }

        stage("docker setup") {
            when {
                branch('FrontEnd')
            }
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                    echo "docker setup"
                sh "docker-compose up -d"
                }
            }
        }

        stage('Build FrontEnd') {
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


        stage("Execute system tests") {
        	steps {
                echo "[front end test program execute commend]"
            }
            post {
                always {
                    cleanup{
                        sh script: "docker-compose down", returnStatus: true
                    }
                }
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