from http.server import BaseHTTPRequestHandler, HTTPServer
from FileManager import FileManager
from SerialManager import SerialManager

class WebServer(BaseHTTPRequestHandler):
    serialManager = SerialManager()
    fileManager = FileManager()

    def do_GET(self):
        self.protocol_version = "HTTP/1.1"
        self.send_response(200)
        self.send_header("Content-Length", 0)
        self.end_headers()

        content_len = int(self.headers.get('Content-Length'))
        post_body = self.rfile.read(content_len)
        self.serialManager.sendAnimation(self.fileManager.readAnimation(post_body.decode("utf-8")), 0.2)
        return

    def do_POST(self):
        self.protocol_version = "HTTP/1.1"
        self.send_response(200)    
        self.send_header("Content-Length", 0)    
        self.end_headers()

        content_len = int(self.headers.get('Content-Length'))
        post_body = self.rfile.read(content_len)        
        self.fileManager.saveAnimation(post_body.decode("utf-8"))        
        return

def run():
    server = ('', 2727)
    httpd = HTTPServer(server, WebServer)
    httpd.serve_forever()
run()