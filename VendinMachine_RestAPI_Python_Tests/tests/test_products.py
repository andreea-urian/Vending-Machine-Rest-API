import unittest
import requests
import urllib3

urllib3.disable_warnings(urllib3.exceptions.InsecureRequestWarning)
url = "https://localhost:7261/api/product"

class TestProducts(unittest.TestCase):
    def test1_add_products(self):
        json_data = {
            "ColumnId": 1,
            "Name": "Cola",
            "Price": 5.5,
            "Quantity": 10
        }
        response = requests.post(url, json=json_data, verify=False)
        self.assertEqual(response.status_code, 200)

    def test2_add_products_with_various_bodies(self):
        json_data_list = [
            {"Name": "Cola", "Price": 5.5, "Quantity": 10},  # Missing ColumnId
            {"ColumnId": 2, "Name": "Cola", "Price": 5.5},   # Missing Quantity
            {"ColumnId": 2, "Price": 5.5, "Quantity": 10},   # Missing Name
            {"ColumnId": 2, "Name": "Cola", "Price": 5.5},   # Missing Quantity
        ]

        for json_data in json_data_list:
            with self.subTest(json_data=json_data):
                response = requests.post(url, json=json_data, verify=False)
                self.assertEqual(response.status_code, 400, f"Failed with JSON: {json_data}")


    def test3_get_products(self):
        response = requests.get(url, verify=False)
        data = response.json()
        number_of_items = len(data)
        self.assertEqual(response.status_code, 200)
        self.assertEqual(number_of_items, 1) # after 1 succeful add product

    def test4_get_product_from_column_1(self):
        response = requests.get(url + '/1', verify=False)
        data = response.json()
        self.assertEqual(response.status_code, 200)
        self.assertEqual(data['columnId'], 1) # after 1 succeful add product

    def test5_get_product_from_wrong_column(self):
        response = requests.get(url + '/100', verify=False)
        self.assertEqual(response.status_code, 404)

    def test6_update_product_from_column(self):
        json_data = {
            "ColumnId": 1,
            "Name": "Cola",
            "Price": 20,
            "Quantity": 10
        }
        response = requests.put(url + '/1', json=json_data, verify=False)
        self.assertEqual(response.status_code, 200)
        response = requests.get(url + '/1', verify=False)

        data = response.json()
        self.assertEqual(data['price'], 20)

    def test7_update_product_from_wrong_column(self):
        json_data = {
            "ColumnId": 1,
            "Name": "Cola",
            "Price": 20,
            "Quantity": 10
        }
        response = requests.put(url + '/100', json=json_data, verify=False)
        self.assertEqual(response.status_code, 404)

    def test8_delete_product_wrong_id(self):
        response = requests.delete(url + '/100', verify=False)
        response = requests.get(url , verify=False)

        data = response.json()
        number_of_items = len(data)
        self.assertEqual(response.status_code, 200)
        self.assertEqual(number_of_items, 1) # verify if delete product fail

    def test9_delete_product(self):
        response = requests.delete(url + '/1', verify=False)
        self.assertEqual(response.status_code, 200)
        response = requests.get(url , verify=False)

        data = response.json()
        number_of_items = len(data)
        self.assertEqual(response.status_code, 200)
        self.assertEqual(number_of_items, 0) # verify if delete product fail
        
