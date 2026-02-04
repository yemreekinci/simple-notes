class NoteModel {
  final int id;
  final String title;
  final String description;
  final int order;

  NoteModel({
    required this.id,
    required this.title,
    required this.description,
    required this.order,
  });

  factory NoteModel.fromJson(Map<String, dynamic> json) {
    return NoteModel(
      id: json['id'],
      title: json['title'],
      description: json['description'],
      order: json['order'],
    );
  }
}
