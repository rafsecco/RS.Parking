FROM mariadb:latest

# That file does the DB initialization but also runs mysql daemon, by removing the last line it will only init
# RUN ["sed", "-i", "s/exec \"$@\"/echo \"not running $@\"/", "/usr/local/bin/docker-entrypoint.sh"]

# needed for intialization
ENV MYSQL_ROOT_PASSWORD=MyDB@123
ENV MARIADB_DATABASE=RS.Parking

COPY scripts/*.sql /docker-entrypoint-initdb.d/

EXPOSE 3306

# FROM mariadb:latest as final
# COPY --from=build /initialized-db /var/lib/mysql
# EXPOSE 3306


# docker pull mariadb
# docker build --tag rs-parking-db-image:initial .
# docker run -d --name rs_parking_db -p 3306:3306 --env MARIADB_ROOT_PASSWORD=MyDB@123 rs-parking-db-image:initial


# ******** Com script de inicialização *********************************************************************************************************************************
# FROM mariadb:latest as builder

# # That file does the DB initialization but also runs mysql daemon, by removing the last line it will only init
# RUN ["sed", "-i", "s/exec \"$@\"/echo \"not running $@\"/", "/usr/local/bin/docker-entrypoint.sh"]

# # needed for intialization
# ENV MARIADB_ROOT_PASSWORD=MariaDBRoot@123
# ENV MARIADB_USER=appRSParking
# ENV MARIADB_PASSWORD=MyDB@appRSParking@123
# ENV MARIADB_DATABASE=RS.Parking

# COPY setup.sql /docker-entrypoint-initdb.d/

# # Need to change the datadir to something else that /var/lib/mysql because the parent docker file defines it as a volume.
# # https://docs.docker.com/engine/reference/builder/#volume :
# #       Changing the volume from within the Dockerfile: If any build steps change the data within the volume after
# #       it has been declared, those changes will be discarded.
# # RUN ["/usr/local/bin/docker-entrypoint.sh", "mysqld", "--datadir", "/initialized-db", "--aria-log-dir-path", "/initialized-db"]
# RUN ["/usr/local/bin/docker-entrypoint.sh", "mysqld", "/docker-entrypoint-initdb.d", "/initialized-db", "--aria-log-dir-path", "/initialized-db"]

# FROM mariadb:latest

# # needed for intialization
# ENV MARIADB_ROOT_PASSWORD=MariaDb@123
# ENV MARIADB_USER=appLog
# ENV MARIADB_PASSWORD=MyDB@AppLog@123
# ENV MARIADB_DATABASE=RS.Log

# COPY --from=builder /initialized-db /var/lib/mysql

# EXPOSE 3306
