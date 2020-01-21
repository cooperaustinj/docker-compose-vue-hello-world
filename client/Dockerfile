FROM node:lts-alpine as build-env
WORKDIR /src/client
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

FROM build-env as debug-env
RUN apk update && \
    apk add git
ENTRYPOINT [ "npm", "run", "serve" ]

FROM build-env as test-env
RUN npm run test:unit

FROM nginx:1.16.0-alpine as prod-env
COPY --from=build-env /src/client/dist /usr/share/nginx/html
RUN rm /etc/nginx/conf.d/default.conf
COPY nginx/nginx.conf /etc/nginx/conf.d
EXPOSE 8080
CMD ["nginx", "-g", "daemon off;"]