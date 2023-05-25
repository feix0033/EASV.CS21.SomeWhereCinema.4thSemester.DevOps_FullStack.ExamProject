pipeline {
    agent any
    stages {
        stage ('test stage'){
            agent {
                docker {
                    image 'mcr.microsoft.com/dotnet/sdk:7.0'
                }
            }
            steps {
                sh 'dotnet'
                sh 'node -v'
                echo 'jenkins working !'
            }
        }
    }
}