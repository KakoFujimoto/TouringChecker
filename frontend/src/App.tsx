import { useState } from "react";
import type { WeatherTomorrow } from "./types";

function App() {
  const [city, setCity] = useState("Tokyo");
  const [weather, setWeather] = useState<WeatherTomorrow | null>(null);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState<string | null>(null);

  const fetchWeather = async () => {
    setLoading(true);
    setError(null);

    try {
      const res = await fetch(
        `https://localhost:7009/api/weather/tomorrow?city=${city}`
      );

      if (!res.ok) {
        throw new Error(`HTTP error: ${res.status}`);
      }

      const data: WeatherTomorrow = await res.json();
      setWeather(data);
    } catch (e) {
      setError("天気情報の取得に失敗しました");
    } finally {
      setLoading(false);
    }
  };

  return (
    <div style={{ padding: "1rem" }}>
      <h1>Touring Checker</h1>

      <div>
        <input
          value={city}
          onChange={(e) => setCity(e.target.value)}
          placeholder="都市名"
        />
        <button onClick={fetchWeather}>取得</button>
      </div>

      {loading && <p>読み込み中...</p>}
      {error && <p style={{ color: "red" }}>{error}</p>}

      {weather && (
        <div>
          <h2>{weather.city}</h2>
          <p>日付: {weather.date}</p>
          <p>天気: {weather.weather}</p>
          <p>気温: {weather.temperature} ℃</p>

          {weather.canRide ? (
            <p style={{ color: "green", fontWeight: "bold" }}>
              ツーリング可能
            </p>
          ) : (
            <p style={{ color: "red", fontWeight: "bold" }}>
              ツーリング不可：{weather.reason}
            </p>
          )}
        </div>
      )}
    </div>
  );
}

export default App;
