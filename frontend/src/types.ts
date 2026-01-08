export type WeatherTomorrow = {
  city: string;
  date: string;
  weather: string;
  temperature: number;
  canRide: boolean;
  reason?: string;
};

export type TouringCheckResult = {
  cityName: string | null;
  lattitude: number;
  longitude: number;
  weather: string;
  isTouringRecommended: boolean;
};
