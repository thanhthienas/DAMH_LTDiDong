import 'dart:convert';
import 'package:http/http.dart' as http;

// Model ExerciseList
class ExerciseList {
  final int id;
  final String name;
  final String description;

  ExerciseList({required this.id, required this.name, required this.description});

  // Parse JSON to ExerciseList object
  factory ExerciseList.fromJson(Map<String, dynamic> json) {
    return ExerciseList(
      id: json['id'],
      name: json['name'],
      description: json['description'],
    );
  }

  // Convert ExerciseList object to JSON
  Map<String, dynamic> toJson() {
    return {
      'id': id,
      'name': name,
      'description': description,
    };
  }
}

// Service ApiService
class ApiService {
  final String baseUrl = "http://your-api-url/api/ExerciseListApi"; // Replace with your actual API URL

  // Get all exercise lists
  Future<List<ExerciseList>> getExerciseList() async {
    try {
      final response = await http.get(Uri.parse(baseUrl));

      if (response.statusCode == 200) {
        List<dynamic> data = json.decode(response.body);
        return data.map((item) => ExerciseList.fromJson(item)).toList();
      } else {
        throw Exception('Failed to load exercise list');
      }
    } catch (e) {
      rethrow;
    }
  }

  // Get exercise list by ID
  Future<ExerciseList> getExerciseListById(int id) async {
    try {
      final response = await http.get(Uri.parse('$baseUrl/$id'));

      if (response.statusCode == 200) {
        return ExerciseList.fromJson(json.decode(response.body));
      } else {
        throw Exception('Failed to load exercise');
      }
    } catch (e) {
      rethrow;
    }
  }

  // Add a new exercise list
  Future<void> addExerciseList(ExerciseList exerciseList) async {
    try {
      final response = await http.post(
        Uri.parse(baseUrl),
        headers: {'Content-Type': 'application/json'},
        body: json.encode(exerciseList.toJson()),
      );

      if (response.statusCode != 201) {
        throw Exception('Failed to add exercise');
      }
    } catch (e) {
      rethrow;
    }
  }

  // Update an exercise list
  Future<void> updateExerciseList(int id, ExerciseList exerciseList) async {
    try {
      final response = await http.put(
        Uri.parse('$baseUrl/$id'),
        headers: {'Content-Type': 'application/json'},
        body: json.encode(exerciseList.toJson()),
      );

      if (response.statusCode != 204) {
        throw Exception('Failed to update exercise');
      }
    } catch (e) {
      rethrow;
    }
  }

  // Delete an exercise list
  Future<void> deleteExerciseList(int id) async {
    try {
      final response = await http.delete(Uri.parse('$baseUrl/$id'));

      if (response.statusCode != 204) {
        throw Exception('Failed to delete exercise');
      }
    } catch (e) {
      rethrow;
    }
  }
}
