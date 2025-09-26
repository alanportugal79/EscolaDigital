#stage 1
FROM node:22.14.0 AS build
WORKDIR /usr/src/app
COPY . .
RUN npm install
RUN npm run build
#stage 2
FROM nginx:alpine
COPY ./nginx.conf /etc/nginx/conf.d/default.conf
COPY --from=build /usr/src/app/dist /usr/share/nginx/html/app
CMD ["/bin/sh",  "-c",  "exec nginx -g 'daemon off;'"]
EXPOSE 80