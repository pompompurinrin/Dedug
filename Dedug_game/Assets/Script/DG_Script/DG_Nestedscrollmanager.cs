using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class DG_Nestedscrollmanager : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    //nestedscrollmanager가 스크롤 뷰 안에 있는 스크립트이므로 이 스크립트를 이용한 프로젝트에서는 스크롤 뷰 안의 입력에만 반응함

    const int SIZE = 4;
    //상수는 프로그래밍에서 값을 한 번 할당하면 그 값을 변경할 수 없는 식별자를 말한다.
    //즉, 한 번 정의된 상수는 프로그래밍 실행 동안 변하지 않는다.
    //상수의 선언은 주로 const나 final을 사용하는데, 이번에는 const를 썼다.
    //const를 이용하여 상수를 선언하는데, 이때 int를 사용하여 상수가 정수형 데이터 타입임을 알려주는 것이다.
    // const int = 1.4.5 등 정수만 가능해. 소수 이런 거 절 대 올 수 없는 것!
    // 우리는 상수를 사용해서 파일 내 스크롤 뷰 속 content의 자식 개수를 할당했다.
    //우리 size는 메인 스토리, 캐1, 캐2, 캐3, 캐4까지 총 5개이지만, 메인스토리는 고정이므로 4개만 할당한다.
    float[] pos = new float[SIZE];
    //float 타입의 배열을 생성해보자. 배열은 동일한 데이터 타입을 갖는 요소들의 모임.
    //즉 이번에 생성한 배열 내 모든 요소들은 동일하게 float 데이터 타입이다.
    //pos는 지금 만든 배열의 이름이다. 
    // 아까 지정한 SIZE = 4. 이걸 배열 생성에 넣어 배열의 크기를 나타내는 상수가 된 것이다. 
    //우리 배열은 SIZE 크기만큼의 float 타입의 요소를 갖는 것
    // 결론적으로 이 줄은 크기가 SIZE인 float타입의 배열을 생성하고, 그 이름을 pos라는 변수에 할당한 것.

    // 우리는 이 배열에 스크롤바의 위치를 넣을 것
    // 하이어라키 창에서 스크롤바 버티컬 선택하고 인스펙터 창에서 스크롤바 하위에 있는 현재 Value 값이 스크롤 바의 위치
    // value는 0에서 1까지의 값을 가지며, 스크롤이 맨 위일 때 0이고 맨 아래일 때 1임

    float distance; //= pos들 간의 간격

    void Start()
    {
     distance = 1f / (SIZE - 1);
        // value 총 길이는 1, 근데 이걸 content의 자식들이 사이좋게 나눠야 가져야 하는 것.
        // 그래서 1을 3로 나누는 것. 왜냐하면 (  |   |   |   | ) 이렇게 4개 개체가 길이를 나눠가진다고 하면 3로 나누면 각각의 거리가 나오니까.

        for (int i = 0; i < SIZE; i++)
        { pos[i] = 1f - (distance * i); }
        // i= 0이라고 지정. i가 1씩 증가되는데, 4보다 작다. 
        //pos[i] = pos 배열의 i는 배열의 값은 거리 * i 

        //for (int i = 0; i < SIZE; i++)  pos[i] = distance * i; 라고 썼더니 아래에서부터 위로 스크롤 시작하는 문제 발생
        //지피티가 아래와 같이 설명해 줌
        //스크롤 위치가 아래에서부터 시작하는 것은 스크롤바의 Value 값이 큰 값에서 작은 값으로 가는 것이기 때문입니다. 스크롤바의 Value 값은 0에서 1 사이의 값이어야 합니다.

        //현재 코드에서 pos 배열을 초기화할 때, 각 요소에 distance *i 값을 할당하고 있습니다.이 때, i가 증가함에 따라 값이 증가하게 되어 스크롤 위치가 아래에서부터 시작합니다.

        //아래로 스크롤이 되도록 하려면 초기화 시에 pos 배열에 할당되는 값의 순서를 반대로 해주면 됩니다. 즉, 가장 아래에 있는 요소에는 1, 그 위에 있는 요소에는 1에 가까운 값이 할당되도록 만들면 됩니다.

        // 결국 문제가 해결되지 않았음......그래서 아래 한 줄을 추가함.

      
        // 이건 스크롤바의 밸류 값을 1로 초기화 하겠다는 것임. 근데 해결되지 않았음.
        //해결 함. 방법 : 인스펙터에서 초기값을 1로 설정하였음. 윗 줄의 { pos[i] = 1f - (distance * i); }로 바꾼 건 필요한 작업이었음.
        // 이때 {}는 없어도 잘 작동하였음. 이유는 잘 모르겠음.
    }

    public void OnBeginDrag(PointerEventData eventData) //eventData는 마우스를 클릭했을 때
    { }
    public void OnDrag(PointerEventData eventData)
    { }
    public void OnEndDrag(PointerEventData eventData)
    { }


}
