pipeline {
    agent any

    triggers {
        pollSCM ( "H * * * *")
    }

    environment {
        CI = 'true' 
        DOTNET_ROOT="/usr/bin/dotnet"
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
        stage('Build FrontEnd') {
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            
            steps {
                sh ('ls')
                sh ('cd SomeWhereCinema.FrontEnd')
                dir ('SomeWhereCinema.FrontEnd'){
                    sh 'npm install'
                    sh 'ng build'
                }
            }
        }

        stage ('build dotnet'){
            agent any
            steps {
                sh 'dotnet --version'
            }
        }

        stage('Test') { 
            steps {
                echo 'this is test process'
            }
        }
    }

    post {
        always {
            deleteDir()
        }
    }
}