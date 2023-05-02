pipeline {
    agent {
        docker {
            image 'node:16-alpine'
            args '-p 3000:3000'
        }
    }
    environment {
        CI = 'true' 
        DOTNET_ROOT="/usr/bin/dotnet"
        PATH = "/usr/bin/dotnet:$PATH"
    }
    stages {
        stage('Build') {
            steps {
                sh 'npm --version'
                sh 'node --version'
                sh 'echo DOTNET_ROOT'
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