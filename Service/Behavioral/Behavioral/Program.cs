using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavioral
{

}
/*
 *Chain of Response là một trong nhưungx pattern thuộc nhóm hành vi  (Behavior) nó cho phép 
 Một đối tượng gửi một yêu cầu nhưng không biết đối tượng nào sẽ nhận và xứ lý nó.Điều này được thực hiện bằng cách kết nối các đối tượng nhận yêu cầu thành một chuỗi.
 Chain of Responseblity pattern hoạt động như một danh sách liên kết (Linked list) với việc đệ quy duyệt qua các phần tử

Các thanhf phần tham gia mẫu Chain of Responsibilty:
Handler : Định nghĩa 1 inteface để xử lý các yêu cầu .Gán cho đối tượng succeror 
ConcreteHandler :Xử lý yêu cấu có thể truy cập đối tượng successor ( thuộc đối tượng Handler).Nếu đối tượng ConcreteHandler không thể xử lý được yêu cầu ,nó sẽ gửi lời yêu cầu cho successỏ của nó 
Client: tạo ra các yêu cầu và yêu cầu đó sẽ được gửi đến các đối tượng tiếp nhận 

 */