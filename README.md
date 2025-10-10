ML Integration Mini-Challenge (Option C – Route B)

Author: Tabish Khan
Challenge Completed: Communicate with an External Model (Python API)
Unity Version: Unity 6.0.0 (6000.0.47f1 LTS)
Python Version: 3.11 (Flask 3.1.2)
Duration: ~4 hours

🧠 Overview

This project demonstrates a real-time data exchange between Unity and a Python Flask API, simulating how Unity can visualize feedback from a machine-learning model.

Inspired by NEPTUNE’s rhythm-feedback system, this demo mimics AI-driven music feedback, where predictions such as “In Sync”, “Off Beat”, and “Pitch Drift” are returned with a confidence value (0–1).

Unity continuously fetches this data every 2 seconds and:

Displays the prediction text and confidence percentage,

Smoothly transitions the cube color from red → yellow → green based on confidence.

🧩 Project Architecture
Python Backend

Flask REST API (ml_api.py) runs locally on http://127.0.0.1:5000/predict.

Returns simulated JSON data such as:

{
  "prediction": "In Sync",
  "confidence": 0.72
}


In a real ML setup, this endpoint could send predictions from a trained AI model (e.g., TensorFlow or PyTorch).

Unity Frontend

MLCommunicator.cs: Sends asynchronous HTTP requests to the Flask API and parses the JSON response.

FeedbackCube: Visually reflects confidence by changing its color using Color.Lerp.

FeedbackText (TMP): Displays live prediction and confidence values.

MLManager: Central GameObject managing communication and updates.

▶️ Instructions to Run
1️⃣ Start the Python API

In Command Prompt, navigate to the project folder:

cd C:\UnityProjects\Neptune_ML_Integration
pip install flask
python ml_api.py


You should see:

* Running on http://127.0.0.1:5000


Keep this terminal open.

2️⃣ Run the Unity Project

Open Neptune_ML_Integration in Unity 6.0.0 LTS.

Open the SampleScene.

In the MLManager object, assign:

Cube: FeedbackCube

Feedback Text: TMP Text element

Press Play ▶️

Observe live predictions and color transitions.

🧾 Notes, Assumptions & Improvements

The API currently returns random predictions for demonstration.

Unity ↔ Python communication uses HTTP locally (localhost:5000).

Both Unity and Flask must run simultaneously.

Future improvements:

Integrate an actual ML model for rhythm or pitch feedback.

Add real-time music input or sensor-based features.

Use confidence values for lighting or particle visualizations.

🎬 Short Screen Recording

A short 30–45 second video (demo.mp4) demonstrates:

Live prediction updates,

Cube color transitions,

Flask server running alongside Unity.
End of README