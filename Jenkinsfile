pipeline {
    agent { dockerfile true }
    stages {
        stage ('test stage'){
            steps {
                sh 'dotnet -v'
                sh 'node -v'
                echo 'jenkins working !'
            }
        }
    }
}