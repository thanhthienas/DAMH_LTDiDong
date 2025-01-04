import 'dart:io';

import 'package:flutter/material.dart';
import 'package:flutter_dotenv/flutter_dotenv.dart';
import 'package:nhom6_android_studio/screens/login_screen.dart';

Future<void> main() async {
  await dotenv.load(fileName: ".env");
  // Dòng code riêng của mình để chạy riêng trên mày(không được sửa) (Đức)
  // HttpOverrides.global = MyHttpOverrides();
  runApp(const MyApp());
}

// Dòng code riêng của mình để chạy riêng trên mày(không được sửa) (Đức)
// class MyHttpOverrides extends HttpOverrides {
//   @override
//   HttpClient createHttpClient(SecurityContext? context) {
//     return super.createHttpClient(context)
//       ..badCertificateCallback = (X509Certificate cert, String host, int port) => true;
//   }
// }

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Chăm sóc sức khỏe của bạn',
      theme: ThemeData(
        primarySwatch: Colors.blue,
      ),
      home: const LoginScreen(),
    );
  }
}
