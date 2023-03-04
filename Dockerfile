FROM mono:latest

RUN mkdir /app

COPY . /app

CMD ["mono", "/app/Program.exe"]
