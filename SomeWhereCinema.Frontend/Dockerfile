### STAGE 1: Build ###
FROM node:16-alpine3.16 AS build
WORKDIR /usr/src/app
# COPY SomeWhereCinema.Frontend/package.json SomeWhereCinema.Frontend/package-lock.json ./
COPY package.json package-lock.json ./

RUN npm install
COPY . .

# RUN npm run build
RUN npm install -g @angular/cli
COPY . .

RUN ng build
### STAGE 2: Run ###
FROM nginx:1.17.1-alpine
COPY nginx.conf /etc/nginx/nginx.conf
COPY --from=build /usr/src/app/dist/some-where-cinema.frontend /usr/share/nginx/html
