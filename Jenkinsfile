pipeline {
    agent {
        docker {
            image 'hello-world'
        }
    }
    stages {
        stage ('test stage'){
            steps {
                echo 'docker -v'
                echo 'jenkins working !'
            }
        }
    }
}