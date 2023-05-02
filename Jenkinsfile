pipeline {
    agent any

    triggers{
        pollSCM("H * * * *")
    }
    
    environment {
        CI = 'true' 
        DOTNET_ROOT="/usr/bin/dotnet"
        PATH = "/usr/bin/dotnet:$PATH"
    }

    stages {
        stage('Build') {
            agent {
                docker {
                    image 'node:16-alpine'
                    args '-p 3000:3000'
                }
            }
            
            steps {
                sh 'npm --version'
                sh 'node --version'
                
            }
        }
        stage ('build dotnet'){
            agent any
            steps {
                dir( 'SomeWhereCinema.Backend'){
                sh 'dotnet build'
                }
            }
        }

        stage('Test') { 
            steps {
                echo 'this is test process'
            }
        }

        stage ('Deploy') {
            when {
                branch 'BackEnd'
            } 
            steps{
                echo 'deploy'
            }
        }
    }

    post {
        always {
            deleteDir()
        }
    }

}