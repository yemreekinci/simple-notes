import 'package:dio/dio.dart';
import 'package:flutter/foundation.dart';

class ApiClient {
  late final Dio dio;

  ApiClient() {
    dio = Dio(
      BaseOptions(
        baseUrl: _baseUrl,
        headers: {'Content-Type': 'application/json'},
      ),
    );
  }

  String get _baseUrl {
    if (kIsWeb) {
      return 'http://localhost:5087/api';
    }
    return 'http://10.0.2.2:5087/api';
  }
}
