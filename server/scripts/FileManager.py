import os

class FileManager:
    location = os.path.dirname(__file__) + "/../animations/"

    def saveAnimation(self, animation):
        animationFile = None
        animationArray = animation.split("\n")
        i = 0
        while i < len(animationArray):
            if(i  == 0):
                filename = animationArray[i]
                filePath = self.location + filename
                self.removeFileIfExists(filePath)
                animationFile = open(filePath, "x")
            else:
                animationFile.write(animationArray[i] + "\n")
            i += 1
        animationFile.close()

    def readAnimation(self, filename):
        animationFile = open(self.location + filename, "r")
        animationArray = animationFile.readlines()
        animationFile.close        
        return animationArray

    def removeFileIfExists(self, filePath):
        if os.path.exists(filePath):
            os.remove(filePath)