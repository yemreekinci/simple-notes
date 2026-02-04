import '../../core/network/api_client.dart';
import '../models/note_model.dart';

class NoteRepository {
  final ApiClient apiClient;

  NoteRepository(this.apiClient);

  Future<List<NoteModel>> getAll() async {
    final response = await apiClient.dio.get('/notes');
    return (response.data as List)
        .map((e) => NoteModel.fromJson(e))
        .toList();
  }

  Future<void> create(String title, String desc) async {
    await apiClient.dio.post('/notes', data: {
      'title': title,
      'description': desc,
    });
  }

  Future<void> update(int id, String title, String desc) async {
    await apiClient.dio.put('/notes', data: {
      'id': id,
      'title': title,
      'description': desc,
    });
  }

  Future<void> delete(int id) async {
    await apiClient.dio.delete('/notes/$id');
  }

  Future<void> deleteAll() async {
    await apiClient.dio.delete('/notes');
  }

  Future<void> reorder(List<int> ids) async {
    await apiClient.dio.put('/notes/reorder', data: {
      'noteIds': ids,
    });
  }
}
