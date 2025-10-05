using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
    {
        public sealed class ThreadSafeLazyInitializedSingleton
        {
            // 1. Biến tĩnh và volatile
            // volatile đảm bảo rằng việc gán giá trị cho 'instance' hoàn tất trước khi giá trị đó được đọc.
            private static volatile ThreadSafeLazyInitializedSingleton instance;

            // Đối tượng khóa (lock object) để đồng bộ hóa luồng.
            private static readonly object lockObject = new object();

            // 2. Constructor riêng (private)
            private ThreadSafeLazyInitializedSingleton()
            {
                // Constructor riêng ngăn việc khởi tạo trực tiếp từ bên ngoài.
            }

            // 3. Phương thức truy cập công khai và tĩnh
            public static ThreadSafeLazyInitializedSingleton GetInstance()
            {
                // Kiểm tra lần 1: Giúp 99% các lần gọi không cần lock, cải thiện hiệu suất.
                if (instance == null)
                {
                    // Khóa (lock) chỉ khi đối tượng chưa được tạo.
                    lock (lockObject)
                    {
                        // Kiểm tra lần 2: Đảm bảo chỉ một luồng tạo đối tượng
                        if (instance == null)
                        {
                            instance = new ThreadSafeLazyInitializedSingleton();
                        }
                    }
                }
                return instance;
            }
        }
}
