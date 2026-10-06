# Part 03 — answers


## BlockedUsersTime complexity before:
 $O(n \times m)$ (بسبب استخدام Contains داخل حلقة التكرار على List عادية).Time (ms) before: (سجل الرقم اللي طلع معاك قبل التعديل، مثلاً: ~120 ms)What did you change? تم تحويل الـ List الخاصة بالـ blockedIds إلى HashSet<int> لجعل عملية البحث تتم في زمن ثابت $O(1)$.Time complexity after: $O(n + m)$ (حيث $n$ هو بناء الـ Set و $m$ هو البحث داخلها بزمن $O(1)$ لكل عنصر).



## Students

What was the problem? الكلاس كان ينشئ قائمة تحتوي على مليون طالب (1_000_000) في الذاكرة دفعة واحدة ويستهلك موارد وقت المعالجة، على الرغم من أن البرنامج يحتاج إلى طباعة أول 3 طلاب فقط ثم يتوقف (break).

What did you change? تم تغيير نوع الإرجاع إلى IEnumerable<Student> واستخدام yield return (تطبيق Lazy Evaluation) بحيث يتم إنشاء العناصر وتوليدها عند الطلب فقط، ولن يتم إنشاء باقي الطلاب طالما أن حلقة التكرار توقف عند الطالب الثالث.
