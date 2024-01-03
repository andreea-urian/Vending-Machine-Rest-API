import unittest
from customTestResult import CustomTestResult

if __name__ == '__main__':
    loader = unittest.TestLoader()
    suite = loader.discover('tests')

    runner = unittest.TextTestRunner(resultclass=CustomTestResult)
    runner.run(suite)
