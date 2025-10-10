from flask import Flask, jsonify
import random

app = Flask(__name__)

@app.route('/predict', methods=['GET'])
def predict():
    feedback = ["In Sync", "Off Beat", "Steady Groove", "Pitch Drift", "Perfect Harmony"]
    result = {
        "prediction": random.choice(feedback),
        "confidence": round(random.uniform(0.5, 1.0), 2)
    }
    return jsonify(result)


if __name__ == '__main__':
    app.run(host='127.0.0.1', port=5000)
