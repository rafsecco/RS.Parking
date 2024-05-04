FROM node:20.12-alpine3.18 AS builder
WORKDIR /app
COPY . .
RUN npm install
RUN npm run build
# RUN npm install -g @angular/cli
# CMD ["ng", "serve", "--host", "0.0.0.0"]

FROM nginx:alpine
COPY --from=builder /app/dist/rs.parking-app-angular/. usr/share/nginx/html
COPY nginx.conf /etc/nginx/nginx.conf
COPY mime.types /etc/nginx/mime.types
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]

# RUN npm run build
# CMD ["npm", "start"]

# docker pull node:20.12-alpine3.18
# docker pull nginx:alpine
# docker build --tag rs-parking-angular-image .
# docker run –d –p 8080:80 --name rs_parking_angular_image rs-parking-angular-image
