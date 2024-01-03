import unittest

class CustomTestResult(unittest.TextTestResult):
    def startTest(self, test):
        self.testsRun += 1
        print(f'{test._testMethodName} started')

    def stopTest(self, test):
        print(f'{test._testMethodName} ended\n')

    def addSuccess(self, test):
        green = '\033[92m'
        reset = '\033[0m'
        print(f'{green}{test._testMethodName} passed{reset}')

    def addFailure(self, test, err):
        red = '\033[91m'
        reset = '\033[0m'
        print(f'{red}{test._testMethodName} failed')
        self.stream.writeln(self._exc_info_to_string(err, test))
        print(f'{reset}\033[A\033[A')

    def addError(self, test, err):
        print(f'{test._testMethodName} had an error')
        self.stream.writeln(self._exc_info_to_string(err, test))

    def printErrors(self):
        pass
