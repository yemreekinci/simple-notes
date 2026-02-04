import 'package:flutter/material.dart';
import 'package:get/get.dart';

import '../controllers/note_controller.dart';
import '../../../core/routes/app_routes.dart';

class NoteListPage extends StatelessWidget {
  const NoteListPage({super.key});

  @override
  Widget build(BuildContext context) {
    final controller = Get.find<NoteController>();

    return Scaffold(
      appBar: AppBar(
        title: const Text(
          'Simple Notes',
          style: TextStyle(fontWeight: FontWeight.bold),
        ),
        actions: [
          IconButton(
            icon: const Icon(Icons.delete_forever),
            onPressed: () async {
              final result = await Get.dialog<bool>(
                AlertDialog(
                  title: const Text('Delete all notes?'),
                  content: const Text('This action cannot be undone.'),
                  actions: [
                    TextButton(
                      onPressed: () => Get.back(result: false),
                      child: const Text('Cancel'),
                    ),
                    TextButton(
                      onPressed: () => Get.back(result: true),
                      child: const Text('Delete'),
                    ),
                  ],
                ),
              );

              if (result == true) {
                controller.deleteAll();
              }
            },
          ),
        ],
      ),

      floatingActionButton: FloatingActionButton(
        backgroundColor: Colors.black,
        foregroundColor: Colors.white,
        onPressed: () {
          Get.toNamed(AppRoutes.noteForm);
        },
        child: const Icon(Icons.add),
      ),

      body: Padding(
        padding: const EdgeInsets.all(16),
        child: Obx(() {
          if (controller.isLoading.value) {
            return const Center(child: CircularProgressIndicator());
          }

          if (controller.notes.isEmpty) {
            return const Center(
              child: Column(
                mainAxisSize: MainAxisSize.min,
                children: [
                  Icon(Icons.note_alt_outlined, size: 64, color: Colors.black26),
                  SizedBox(height: 4),
                  Text(
                    'No notes yet',
                    style: TextStyle(
                      fontSize: 18,
                      fontWeight: FontWeight.w400,
                    ),
                  ),
                  SizedBox(height: 4),
                  Text(
                    'Tap + to add your first note',
                    style: TextStyle(color: Colors.black54),
                  ),
                ],
              ),
            );
          }

          return ReorderableListView.builder(
            itemCount: controller.notes.length,
            onReorder: (oldIndex, newIndex) {
              if (newIndex > oldIndex) newIndex--;

              final item = controller.notes.removeAt(oldIndex);
              controller.notes.insert(newIndex, item);

              controller.reorderNotes(
                controller.notes.map((e) => e.id).toList(),
              );
            },
            itemBuilder: (context, index) {
              final note = controller.notes[index];

              return Card(
                key: ValueKey(note.id),
                elevation: 0,
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(12),
                  side: const BorderSide(color: Colors.black),
                ),
                margin: const EdgeInsets.symmetric(vertical: 4, horizontal: 0),
                child: InkWell(
                  borderRadius: BorderRadius.circular(12),
                  onTap: () {
                    Get.toNamed(
                      AppRoutes.noteForm,
                      arguments: note,
                    );
                  },
                  child: Padding(
                    padding: const EdgeInsets.symmetric(horizontal: 10, vertical: 3),
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        Row(
                          children: [
                            Expanded(
                              child: Text(
                                note.title,
                                style: const TextStyle(
                                  fontSize: 16,
                                  fontWeight: FontWeight.bold,
                                ),
                              ),
                            ),
                            IconButton(
                              icon: const Icon(Icons.delete, color: Colors.black),
                              padding: EdgeInsets.zero,
                              constraints: const BoxConstraints(),
                              onPressed: () async {
                                final result = await Get.dialog<bool>(
                                  AlertDialog(
                                    title: const Text('Delete the note?'),
                                    content: const Text('This action cannot be undone.'),
                                    actions: [
                                      TextButton(
                                        onPressed: () => Get.back(result: false),
                                        child: const Text('Cancel'),
                                      ),
                                      TextButton(
                                        onPressed: () => Get.back(result: true),
                                        child: const Text('Delete'),
                                      ),
                                    ],
                                  ),
                                );

                                if (result == true) {
                                  controller.deleteNote(note.id);
                                }
                              },
                            ),

                          ],
                        ),
                        
                        Text(
                          truncateForList(note.description, 40),
                          style: const TextStyle(color: Colors.black87),
                        ),
                      ],
                    ),
                  ),
                ),
              );
            },
          );
        }),
      ),
    );
  }
}

String truncateForList(String text, int charLimit) {
  final cleanedText = text
      .replaceAll(RegExp(r'\s+'), ' ')
      .trim();

  if (cleanedText.length <= charLimit) {
    return cleanedText;
  }

  return '${cleanedText.substring(0, charLimit)}...';
}

