import 'package:get/get.dart';
import '../../../core/network/api_client.dart';
import '../../../data/repositories/note_repository.dart';
import '../controllers/note_controller.dart';

class NoteBinding extends Bindings {
  @override
  void dependencies() {
    Get.lazyPut(() => ApiClient());
    Get.lazyPut(() => NoteRepository(Get.find()));
    Get.lazyPut(() => NoteController(Get.find()));
  }
}
