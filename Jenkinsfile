pipeline {
  agent any
  stages {
    stage('Build FrontEnd') {
      agent {
        node {
          label 'node16'
        }

      }
      when {
        branch 'FrontEnd*'
      }
      steps {
        dir(path: 'SomeWhereCinema.Frontend') {
          sh 'npm cache clean --force'
          sh 'npm cache verify'
          sh 'npm install npm'
          sh 'npm install'
          sh 'ng build'
        }

      }
    }

    stage('Build BackEnd') {
      parallel {
        stage('Build BackEnd') {
          agent any
          when {
            branch 'BackEnd*'
          }
          steps {
            dir(path: 'SomeWhereCinema.Backend') {
              sh 'dotnet build'
            }

          }
        }

        stage('') {
          steps {
            dotnetBuild()
          }
        }

      }
    }

    stage('Test BackEnd') {
      agent any
      when {
        branch 'BackEnd*'
      }
      post {
        success {
          echo '====++++Test BackEnd executed successfully++++===='
          archiveArtifacts 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'
        }

      }
      steps {
        dir(path: 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest') {
          echo 'remove histiory test results'
          sh 'rm -rf TestResults'
          sh 'dotnet add package coverlet.collector'
          sh 'dotnet test --collect:\'Xplat Code Coverage\''
        }

      }
    }

  }
  environment {
    CI = 'true'
    DOTNET_ROOT = '/usr/bin/dotnet'
    PATH = "/usr/bin/dotnet:$PATH"
  }
  post {
    always {
      echo '====++++All stages finish++++===='
      deleteDir()
    }

    success {
      echo '====++++successfully++++===='
    }

    failure {
      echo '====++++failed++++===='
    }

  }
  triggers {
    pollSCM('* * * * *')
  }
}