FROM node:lts-alpine as build-env
WORKDIR /src
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

FROM build-env as debug-env
ENTRYPOINT [ "npm", "run", "serve" ]

FROM build-env as test-env
RUN npm run test:unit

FROM nginx:1.16.0-alpine as prod-env
COPY --from=build /src/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]