import 'package:get/get.dart';
import '../../../data/models/note_model.dart';
import '../../../data/repositories/note_repository.dart';

class NoteController extends GetxController {
  final NoteRepository repository;

  NoteController(this.repository);

  var notes = <NoteModel>[].obs;
  var isLoading = false.obs;

  @override
  void onInit() {
    fetchNotes();
    super.onInit();
  }

  Future<void> fetchNotes() async {
  try {
    isLoading.value = true;
    notes.value = await repository.getAll();
  } catch (e) {
    Get.snackbar('Error', 'Failed to load notes');
  } finally {
    isLoading.value = false;
  }
}

  Future<void> addNote(String title, String desc) async {
    await repository.create(title, desc);
    fetchNotes();
  }

  Future<void> updateNote(int id, String title, String desc) async {
    await repository.update(id, title, desc);
    fetchNotes();
  }

  Future<void> deleteNote(int id) async {
    await repository.delete(id);
    fetchNotes();
  }

  Future<void> deleteAll() async {
    await repository.deleteAll();
    notes.clear();
  }

  Future<void> reorderNotes(List<int> ids) async {
    await repository.reorder(ids);
    fetchNotes();
  }
}
