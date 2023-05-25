pipeline {
    agent any
    stages {
        stage ('test stage'){
            steps {
                withCredentials([
                    usernamePassword(
                        credentialsId: 'f6421fd5-8708-4f4e-a9e9-4ed2097daad6',
                        passwordVariable:'PASSWORD',
                        usernameVariable:'USERNAME'
                    )
                ])
                {
                    sh '''
                        sudo groupadd docker
                        sudo usermod -aG docker ${USER}
                        su -s ${USER}
                        docker run hello-world
                    '''
                }
                
                echo 'docker -v'
                echo 'jenkins working !'
            }
        }
    }
}