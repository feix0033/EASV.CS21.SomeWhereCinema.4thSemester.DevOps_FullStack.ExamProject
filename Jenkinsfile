pipeline {
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

        stage('Build BackEnd') {
            parallel {
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
            }
        }

        stage('Test BackEnd') {
            agent any
            when {
                branch 'BackEnd*'
            }
            post {
                success {
                    archiveArtifacts 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'
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