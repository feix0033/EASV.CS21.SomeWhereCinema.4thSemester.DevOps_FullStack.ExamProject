pipeline {
    agent any
    triggers {
        pollSCM('* * * * *')
    }
    environment {
            DOTNET_CLI_HOME = "/tmp/DOTNET_CLI_HOME"
            HOME = "/tmp/DOTNET_CLI_HOME"
    }
    stages {
        stage ('clean workspace') {
            steps {
                cleanWs()
            }
        }
        stage ('Continuous Integration: Unit Test') {
            parallel {
                stage ('CI_UnitTest_Backend'){
                    agent {
                        docker {
                            image 'mcr.microsoft.com/dotnet/sdk:7.0'
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
                            dir(path: 'SomeWhereCinema.Backend'){
                                archiveArtifacts 'SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'

                                publishCoverage adapters: [
                                    istanbulCoberturaAdapter(
                                        path: 'SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml', 
                                        thresholds:[[
                                            failUnhealthy: true,
                                            thresholdTarget: 'Conditional',
                                            unhealthyThreshold: 80.0, // below 80%
                                            unstableThreshold: 50.0  // below 50%
                                        ]]
                                    )
                                ],
                                checksName: ''
                            }
                        }
                    }
                }

                stage('CI_UnitTest_FrontEnd') {
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
                            sh 'npm install'
                            sh 'npm i @angular/cli'
                            sh 'npm list'
                            // sh 'npm run ng test --no-watch --np-progress --code-coverage'
                            sh 'npm run ng v'
                        }
                    }
                }
            }
        }

        stage ('Continuous Delivery: Build') {
            parallel {
                stage('CI_Build_BackEnd_DotNet') {
                    agent {
                        docker {
                            image 'mcr.microsoft.com/dotnet/sdk:7.0'
                        }
                    }
                    steps {
                        dir(path: 'SomeWhereCinema.Backend') {
                            sh 'dotnet build'
                            sh "docker build -t evensnachi/somewhere-cinema ."
                            // here should push the image to private registry
                        }
                    }
                }
                stage('CD_Build_FrontEnd') {
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
                            sh 'npm install'
                            sh 'npm i @angular/cli'
                            sh 'npm i firebase-tools'
                            sh 'npm run ng build --omit=dev'
                            // here should copy all my frontend code to test environment.
                        }
                    }
                }
            }
        }

        stage("Continuous Release IntegrationTest") {
            agent any
            steps {
                dir(path: 'SomeWhereCinema.Backend') {
                    sh "docker-compose up"
                }
                dir(path: 'SomeWhereCinema.FrontEnd'){
                    sh 'firebase emulator:start'
                    sh 'npm i testcafe'
                    sh 'testcafe --list-browsers'
                    sh 'testcafe all E2ETest/test.ts' 
                }
            }
            post {
                always {
                    dir(path: 'SomeWhereCinema.Backend') {
                        sh script:"docker compose down", returnStatus: true
                    }
                    
                }
            }
        }

        stage ('Continuous Deploy') {
            parallel {
                stage ('CD_FrontEnd_To_Firebase') {
                    agent any
                    steps {
                        dir(path: 'SomeWhereCinema.Frontend') {
                            sh "firebase deploy --token ${firebase} "
                        }
                    }
                }

                stage('CD_BackEnd_To_DockerHub') {
                    agent any
                    steps {
                        dir(path: 'SomeWhereCinema.Backend') {
                            withCredentials(
                                [usernamePassword(
                                    credentialsId: 'docker',
                                    passwordVariable: 'PASSWORD', 
                                    usernameVariable: 'USERNAME')]){
                                sh 'docker login -u ${USERNAME} -p ${PASSWORD}'
                            }
                            sh "docker push evensnachi/somewhere-cinema"
                        }
                    }
                }
            }
        }

        stage ('CD_Performancetesting'){
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