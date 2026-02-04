import 'package:flutter/material.dart';
import 'package:get/get.dart';
import 'core/routes/app_routes.dart';
import 'modules/notes/pages/note_list_page.dart';
import 'modules/notes/pages/note_form_page.dart';
import 'modules/notes/bindings/note_binding.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  @override
  Widget build(BuildContext context) {
    return GetMaterialApp(
      theme: ThemeData(
        appBarTheme: AppBarTheme(
          backgroundColor: Colors.black,
          foregroundColor: Colors.white,
        ),
        floatingActionButtonTheme: FloatingActionButtonThemeData(
          backgroundColor: Colors.black,
          foregroundColor: Colors.white
        )
      ),
      debugShowCheckedModeBanner: false,
      initialRoute: AppRoutes.notes,
      getPages: [
        GetPage(
          name: AppRoutes.notes,
          page: () => const NoteListPage(),
          binding: NoteBinding(),
        ),
        GetPage(
          name: AppRoutes.noteForm,
          page: () => const NoteFormPage(),
        ),
      ],
    );
  }
}
