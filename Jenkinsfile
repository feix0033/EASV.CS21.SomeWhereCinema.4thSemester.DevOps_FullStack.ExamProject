pipeline {
    agent {
        docker {
            image 'node:16-alpine'
            args '-p 3000:3000'
        }
    }
    stages {
        stage ('test stage'){
            steps {
                sh 'node -v'
                echo 'jenkins working !'
            }
        }
    }
}