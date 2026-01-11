import { useState } from "react";
import type { TouringCheckResult } from "./types";

function App() {
  const [currentCity, setCurrentCity] = useState("");
  const [destinationCity, setDestinationCity] = useState("");
  const [result, setResult] = useState<TouringCheckResult | null>(null);

  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const checkTouring = async () => {
    setLoading(true);
    setError(null);
    setResult(null);

    if (!currentCity && !destinationCity){
      setError("出発地または目的地のどちらかを入力してください");
      setLoading(false);
      return;
    }

    try {
      const body: {
        currentLocation?: { cityName: string };
        destination?: { cityName: string };
      } = {};

      if (currentCity) {
        body.currentLocation = { cityName: currentCity };
      }
      if (destinationCity) {
        body.destination = { cityName: destinationCity };
      }

      const res = await fetch("https://localhost:7009/api/weather/check", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(body),
      });

      if (!res.ok) {
        throw new Error(`HTTP error: ${res.status}`);
      }

      const data: TouringCheckResult = await res.json();
      setResult(data);
    } catch (e) {
      setError("ツーリング判定に失敗しました");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ padding: "1rem" }}>
      <h1>Touring Checker</h1>

      <div style={{ marginBottom: "0.5rem" }}>
        <input
          value={currentCity}
          onChange={(e) => setCurrentCity(e.target.value)}
          placeholder="出発地（Kobe など）"
        />
      </div>

      <div style={{ marginBottom: "0.5rem" }}>
        <input
          value={destinationCity}
          onChange={(e) => setDestinationCity(e.target.value)}
          placeholder="目的地（Tokyo など）"
        />
      </div>

      <button onClick={checkTouring} disabled={loading}>
        {loading ? "判定中..." : "明日のツーリングをチェック"}
      </button>

      {error && <p style={{ color: "red" }}>{error}</p>}

      {result && (
        <div style={{ marginTop: "1rem" }}>
          {result.isTouringRecommended ? (
            <p style={{ color: "green", fontWeight: "bold" }}>
              ツーリング可能 🏍️
            </p>
          ) : (
            <p style={{ color: "red", fontWeight: "bold" }}>
              ツーリング非推奨 ☔
            </p>
          )}
        </div>
      )}
    </div>
  );
}

export default App;