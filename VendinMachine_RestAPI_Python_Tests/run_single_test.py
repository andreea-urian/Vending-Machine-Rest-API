import unittest
import sys
from customTestResult import CustomTestResult

test_name = "test_products.py"


def run_test(test_name):
    loader = unittest.TestLoader()
    suite = loader.discover('tests', test_name)

    runner = unittest.TextTestRunner(resultclass=CustomTestResult)
    runner.run(suite)

if __name__ == "__main__":
    run_test(test_name)
