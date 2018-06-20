FROM node:latest

RUN apt-get update && apt-get install -y libfreetype6 libfontconfig xfonts-75dpi xfonts-base

# wkhtmltopdf version 0.12.5 (https://downloads.wkhtmltopdf.org/0.12/0.12.5/wkhtmltox_0.12.5-1.jessie_amd64.deb)
# has a bug which causes it to generate an empty table of contents. Hence we use an older version.
RUN wget https://github.com/wkhtmltopdf/wkhtmltopdf/releases/download/0.12.2.1/wkhtmltox-0.12.2.1_linux-jessie-amd64.deb \
    && dpkg -i wkhtmltox-0.12.2.1_linux-jessie-amd64.deb \
    && rm -f wkhtmltox-0.12.2.1_linux-jessie-amd64.deb

ADD ./Fonts/muli /usr/share/fonts/truetype/muli
RUN fc-cache -fv

WORKDIR /ka
COPY package.json /ka
RUN npm install
