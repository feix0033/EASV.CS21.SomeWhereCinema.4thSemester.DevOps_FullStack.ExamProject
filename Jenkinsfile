pipeline {
    agent any
    }
    stages {
        stage ('test stage'){
            steps {
                sh '''
                sudo groupadd docker
                sudo usermod -aG docker ${USER}
                su -s ${USER}
                docker run hello-world
                '''
                echo 'docker -v'
                echo 'jenkins working !'
            }
        }
    }
}