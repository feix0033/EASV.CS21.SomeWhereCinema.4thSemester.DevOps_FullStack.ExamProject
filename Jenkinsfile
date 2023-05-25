pipeline {
    agent any
    stages {
        stage ('test stage'){
            steps {
                sh 'docker run hello-world'

                echo 'docker -v'
                echo 'jenkins working !'
            }
        }
    }
}