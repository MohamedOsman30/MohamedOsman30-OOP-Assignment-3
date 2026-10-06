## 1. ما هو كل نوع؟ (What is each one?)
- IReadOnlyDictionary<TKey, TValue>: هو واجهة (Interface) تُمثل مجموعة من العناصر المخزنة على هيئة مفاتيح وقيم (Key-Value pairs) وتتيح القراءة فقط، مما يعني أنه لا يوفر أي طرق للإضافة أو الحذف أو التعديل بعد إنشاء الكوليكشن.

- SortedDictionary<TKey, TValue>: هو هيكل بيانات (Collection) يخزن البيانات في أزواج من المفاتيح والقيم، ويقوم تلقائياً ترتيب المفاتيح تصاعدياً أو بناءً على مُقارن مخصص (Custom Comparer).

## 2. الفرق بين IReadOnlyDictionary و Dictionary، ولماذا تُرجع الدوال العامة الأول؟

- الفرق: الـ Dictionary العادي يسمح للمستدعي بتعديل البيانات، إضافة عناصر جديدة، أو حذف عناصر موجودة بحرية. أما IReadOnlyDictionary فيقيد المستدعي بعمليات القراءة والبحث فقط (Keys, Values, TryGetValue, Count, الخ) ويمنع أي تعديل.

### لماذا تُرجع دالة عامة (Public Method) IReadOnlyDictionary بدل Dictionary؟

- لحماية البيانات الداخلية وكبسلتها (Encapsulation). عندما تملك كلاساً يحتفظ ببيانات حساسة أو قاموس داخلي، فإن إرجاعه كـ IReadOnlyDictionary يمنع أي كود خارجي من العبث بهذه البيانات أو تعديلها بالخطأ، ويجبر الكود الخارجي على القراءة فقط.

## 3. الفرق بين SortedDictionary و Dictionary (الترتيب، سرعة البحث، ومتى تختاره)؟

- من حيث الترتيب (Ordering):

الـ Dictionary لا يضمن أي ترتيب للمفاتيح (يخزنها بطريقة تعتمد على الـ Hash).

الـ SortedDictionary يحافظ على الترتيب التلقائي للمفاتيح طوال الوقت.

- من حيث سرعة البحث (Lookup speed): 

لـ Dictionary يوفر سرعة بحث فائقة في زمن ثابت تقريباُ $O(1)$ بالاعتماد على جدول التجزئة (Hash Table).الـ SortedDictionary تكون سرعة البحث فيه $O(\log n)$ لأنه يعتمد على شجرة بحث ثنائية (Binary Search Tree / Red-Black Tree).


- متى تختار SortedDictionary؟ 
تختاره عندما تكون بحاجة ماسة لأن تُطبع البيانات أو يتم المرور عليها (Iteration) وهي مرتبة دائماً بناءً على المفاتيح (مثل تواريخ، أو أسماء أبجدية)، أو عندما تحتاج للبحث عن نطاقات معينة من المفاتيح (Range Queries).

---

# Task 2.2 — Pick the Collection

* **S1 Find a student by national ID — thousands of times a day.**
  * **Collection:** `Dictionary`
  * **Why:** يوفر بحثاً سريعاً جداً بالمفتاح في زمن ثابت $O(1)$ وهو مثالي لعمليات البحث المتكررة.

* **S2 Keep the tags of a course. The same tag must never be stored twice.**
  * **Collection:** `HashSet`
  * **Why:** يمنع تلقائياً تكرار العناصر ويضمن فرادتها مع توفير بحث سريع.

* **S3 Keep a student's grades in the order they were entered. The same grade can appear more than once.**
  * **Collection:** `List`
  * **Why:** يحافظ على ترتيب الإدخال ويسمح بتكرار القيم بحرية.

* **S4 A public method returns the course price list. Callers can read prices but must not add or change any.**
  * **Collection:** `IReadOnlyDictionary`
  * **Why:** يحمي البيانات الداخلية ويمنع الكود الخارجي من تعديلها أو الإضافة إليها.

* **S5 A timetable keyed by session start time. Sessions are added at any moment, and it must always print in time order.**
  * **Collection:** `SortedDictionary`
  * **Why:** يرتب المفاتيح تلقائياً طوال الوقت مما يضمن طباعتها بالترتيب الزمني الصحيح.

* **S6 A method returns results that the caller only loops over once — and may stop early.**
  * **Collection:** `IEnumerable`
  * **Why:** يدعم الـ Lazy Evaluation والتقييم الكسول لتنفيذ العناصر عند الطلب فقط وإيقاف العمليات عند الحاجة.