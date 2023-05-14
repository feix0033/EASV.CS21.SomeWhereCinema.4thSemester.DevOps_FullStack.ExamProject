pipeline {
  agent any 
  environment {
    CI = 'true'
    DOTNET_ROOT = '/usr/bin/dotnet'
    PATH = "/usr/bin/dotnet:$PATH"
  }
  triggers {
    pollSCM('* * * * *')
  }
  stages {
    stage('Build FrontEnd') {
      agent {
        docker {
            image 'node:16-alpine'
            args '-p 3000:3000'
        }

      }
      when {
        branch 'FrontEnd*'
      }
      steps {
        dir(path: 'SomeWhereCinema.Frontend') {
          sh 'npm cache clean --force'
          sh 'npm cache verify'
        //   sh 'npm install npm'
          sh 'npm install'
          sh 'npm i @angular/cli '
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
      }
    }

    stage('Test BackEnd') {
      agent any
      when {
        branch 'BackEnd*'
      }
      steps {
        dir(path: 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest') {
          echo 'remove histiory test results'
          sh 'rm -rf TestResults'
          sh 'dotnet add package coverlet.collector'
          sh 'dotnet test --collect:\'Xplat Code Coverage\''
        }
      }

      post {
        success {
          archiveArtifacts 'SomeWhereCinema.Backend/SomeWhereCinema.UnitTest/TestResults/*/coverage.cobertura.xml'
        }
      }
    }

    stage('deliver Frontend') {
        agent any
        when {
            branch 'FrontEnd'
        }
        steps {
            sh 'git checkout main'
            sh 'git pull'
            sh 'git merge FrontEnd'
            sh 'git push'
        }
      }
  }

}