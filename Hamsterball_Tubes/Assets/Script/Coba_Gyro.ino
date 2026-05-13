// // void setup() {
// //   Serial.begin(115200);
// //   // Contoh: Pakai Pin Analog (Potensiometer) atau MPU6050
// // }

// // void loop() {
// //   // Simulasi pembacaan sensor (Ganti dengan pembacaan sensor aslimu)
// //   int xVal = analogRead(34); // Contoh pin analog
// //   int zVal = analogRead(35);

// //   // Map nilai sensor (0-4095) ke range Unity (-1 sampai 1)
// //   float moveX = (xVal - 2048) / 2048.0;
// //   float moveZ = (zVal - 2048) / 2048.0;

// //   // Kirim data format: "0.50,-0.20"
// //   Serial.print(moveX);
// //   Serial.print(",");
// //   Serial.println(moveZ);

// //   delay(20); // Biar nggak nyepam serial port terlalu kenceng
// // }

// #include <Wire.h>
// #include <Adafruit_MPU6050.h>
// #include <Adafruit_Sensor.h>

// #define SDA_PIN 21
// #define SCL_PIN 22
// #define MPU_ADDR 0x68   // Jika AD0 ke VCC, ganti menjadi 0x69

// Adafruit_MPU6050 mpu;

// void setup() {
//   Serial.begin(115200);
//   delay(1000);

//   Serial.println();
//   Serial.println("Mulai membaca MPU6050 dengan ESP32...");

//   // Inisialisasi I2C ESP32
//   Wire.begin(SDA_PIN, SCL_PIN);
//   Wire.setClock(400000); // 400 kHz, bisa diganti 100000 jika tidak stabil

//   // Inisialisasi MPU6050
//   if (!mpu.begin(MPU_ADDR, &Wire)) {
//     Serial.println("MPU6050 tidak terdeteksi!");
//     Serial.println("Cek wiring: VCC, GND, SDA=GPIO21, SCL=GPIO22.");
//     Serial.println("Jika AD0 ke VCC, ubah MPU_ADDR menjadi 0x69.");
//     while (1) {
//       delay(100);
//     }
//   }

//   Serial.println("MPU6050 terdeteksi.");

//   // Konfigurasi range sensor
//   mpu.setAccelerometerRange(MPU6050_RANGE_8_G);
//   mpu.setGyroRange(MPU6050_RANGE_500_DEG);
//   mpu.setFilterBandwidth(MPU6050_BAND_21_HZ);

//   Serial.println("Konfigurasi selesai.");
//   Serial.println("------------------------------------");
//   delay(500);
// }

// void loop() {
//   sensors_event_t accel;
//   sensors_event_t gyro;
//   sensors_event_t temp;

//   // Ambil data sensor
//   mpu.getEvent(&accel, &gyro, &temp);

//   // Accelerometer dalam m/s^2
//   Serial.print("Accel X: ");
//   Serial.print(accel.acceleration.x);
//   Serial.print(" m/s^2, Y: ");
//   Serial.print(accel.acceleration.y);
//   Serial.print(" m/s^2, Z: ");
//   Serial.print(accel.acceleration.z);
//   Serial.println(" m/s^2");

//   // Gyroscope dari library dalam rad/s
//   // Dikonversi ke derajat/s agar lebih mudah dibaca
//   Serial.print("Gyro  X: ");
//   Serial.print(gyro.gyro.x * 180.0 / PI);
//   Serial.print(" deg/s, Y: ");
//   Serial.print(gyro.gyro.y * 180.0 / PI);
//   Serial.print(" deg/s, Z: ");
//   Serial.print(gyro.gyro.z * 180.0 / PI);
//   Serial.println(" deg/s");

//   // Suhu internal sensor
//   Serial.print("Temp  : ");
//   Serial.print(temp.temperature);
//   Serial.println(" C");

//   Serial.println("------------------------------------");
//   delay(500);
// }

#include <Wire.h>
#include <Adafruit_MPU6050.h>
#include <Adafruit_Sensor.h>

#define SDA_PIN 21
#define SCL_PIN 22
#define MPU_ADDR 0x68

Adafruit_MPU6050 mpu;

void setup() {
  Serial.begin(115200);
  
  // Inisialisasi I2C
  Wire.begin(SDA_PIN, SCL_PIN);

  if (!mpu.begin(MPU_ADDR, &Wire)) {
    // Jika gagal, tetap kirim pesan agar kelihatan di Console Unity
    while (1) {
      Serial.println("0,0"); 
      delay(1000);
    }
  }

  // Setting biar gerakan bola smooth (tidak terlalu liar)
  mpu.setAccelerometerRange(MPU6050_RANGE_2_G);
  mpu.setFilterBandwidth(MPU6050_BAND_21_HZ);
}

void loop() {
  sensors_event_t accel;
  sensors_event_t gyro;
  sensors_event_t temp;
  mpu.getEvent(&accel, &gyro, &temp);

  // MPU6050 outputnya m/s^2 (sekitar -9.8 sampai 9.8)
  // Kita bagi 10 agar range-nya mendekati -1 sampai 1 (standar input Unity)
  float moveX = accel.acceleration.x / 10.0f;
  float moveZ = accel.acceleration.y / 10.0f;

  // KIRIM HANYA ANGKA: "nilaiX,nilaiZ"
  Serial.print(moveX);
  Serial.print(",");
  Serial.println(moveZ);

  delay(20); // 50 FPS, biar bola nggak patah-patah
}