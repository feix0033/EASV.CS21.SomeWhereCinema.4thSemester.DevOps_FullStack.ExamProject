pipeline {
    agent {
        docker {
            image 'node:16-alpine'
            args '-p 3000:3000'
        }
    }
    environment {
        CI = 'true' 
        // DOTNET_ROOT="/home/linuxbrew/.linuxbrew/opt/dotnet/libexec"
        // PATH=$PATH:"/home/linuxbrew/.linuxbrew/opt/dotnet/libexec"
    }
    stages {
        stage('Build') {
            steps {
                sh 'npm --version'
                sh 'node --version'
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