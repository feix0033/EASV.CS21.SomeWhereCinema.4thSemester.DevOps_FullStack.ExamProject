pipeline {
    agent any
    stages {
        stage('build') {
            docker {
                image 'node:6-alpine'
                args '-p 3000:3000'
            }
            steps {
                sh 'echo "Hello World"'

            }
        }
    }
}