
document.addEventListener("DOMContentLoaded", function (event) {


    let output = '';
    const postList = document.querySelector('#firstTbody');

    const renderCode = (codes) => {
        codes.forEach(code => {
            output += `
            <tr class="MaCK" id="${code.id}">
                <td class="cccu fixedcol">
                    <input class="cbTop priceboard"  type="checkbox">
                    <span>${code.nameCode}</span>
                </td>
                <td class="g_r">${code.price_TC}</td>
                <td class="g_c">${code.price_Tran}</td>
                <td class="grf">${code.price_San}</td>`;

                if (code.g3_Buy === code.price_TC) {
                    output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.g3_Buy}">${code.g3_Buy}</td>
                                    <td class="b_r" >${code.kL3_Buy}</td>
                                    `;
                } else if (code.g3_Buy === code.price_San) {
                    output += `<td class="b_f" >${code.g3_Buy}</td>
                                    <td class="b_f" >${code.kL3_Buy}</td>`;
                } else if (code.g3_Buy === code.price_Tran) {
                    output += `<td class="b_c">${code.g3_Buy}</td>
                                    <td class="b_c" >${code.kL3_Buy}</td>`;
                } else if (code.g3_Buy > code.price_TC) {
                    output += `<td class="b_u" >${code.g2_Buy}</td>
                                    <td class="b_u" >${code.kL3_Buy}</td>
                                    `;
                } else if (code.g3_Buy < code.price_TC) {
                    output += `<td class="b_d" >${code.g3_Buy}</td>
                                    <td class="b_d" >${code.kL3_Buy}</td>
                                    `;
                }

                if (code.g2_Buy === code.price_TC) {
                    output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.g2_Buy}">${code.g2_Buy}</td>
                                <td class="b_r" >${code.kL2_Buy}</td>
                                `;
                } else if (code.g2_Buy === code.price_San) {
                    output += `<td class="b_f" >${code.g2_Buy}</td>
                                <td class="b_f" >${code.kL2_Buy}</td>`;
                } else if (code.g2_Buy === code.price_Tran) {
                    output += `<td class="b_c">${code.g2_Buy}</td>
                                <td class="b_c" >${code.kL2_Buy}</td>`;
                }else if (code.g2_Buy > code.price_TC) {
                    output += `<td class="b_u" >${code.g2_Buy}</td>
                                <td class="b_u" >${code.kL2_Buy}</td>
                                `;
                } else if (code.g2_Buy < code.price_TC) {
                    output += `<td class="b_d" >${code.g2_Buy}</td>
                                <td class="b_d" >${code.kL2_Buy}</td>
                                `;
                }

                if (code.g1_Buy === code.price_TC) {
                    output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.g1_Buy}">${code.g1_Buy}</td>
                                    <td class="b_r" >${code.kL1_Buy}</td>
                                    `;
                } else if (code.g1_Buy === code.price_San) {
                    output += `<td class="b_f" >${code.g1_Buy}</td>
                                    <td class="b_f" >${code.kL1_Buy}</td>`;
                } else if (code.g1_Buy === code.price_Tran) {
                    output += `<td class="b_c">${code.g1_Buy}</td>
                                    <td class="b_c" >${code.kL1_Buy}</td>`;
                } else if (code.g1_Buy > code.price_TC) {
                    output += `<td class="b_u" >${code.g1_Buy}</td>
                                    <td class="b_u" >${code.kL1_Buy}</td>
                                    `;
                } else if (code.g1_Buy < code.price_TC) {
                    output += `<td class="b_d" >${code.g1_Buy}</td>
                                    <td class="b_d" >${code.kL1_Buy}</td>
                                    `;
                }

                if (code.price_OrderExecution === code.price_TC) {
                    output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.price_OrderExecution}">${code.price_OrderExecution}</td>
                                            <td class="b_r" >${code.kL_OrderExecution}</td>
                                            <td class="b_r">-1.6432%</td>`;
                } else if (code.price_OrderExecution === code.price_San) {
                    output += `<td class="b_f" >${code.price_OrderExecution}</td>
                                <td class="b_f" >${code.kL_OrderExecution}</td>
                                <td class="b_f" >-1.6432%</td>`;

                } else if (code.price_OrderExecution === code.price_Tran) {
                    output += `<td class="b_c">${code.price_OrderExecution}</td>
                                <td class="b_c" >${code.kL_OrderExecution}</td>
                                <td class="b_c">-1.6432%</td>`;
                } else if (code.price_OrderExecution > code.price_TC) {
                    output += `<td class="b_u" >${code.price_OrderExecution}</td>
                               <td class="b_u" >${code.kL_OrderExecution}</td>
                               <td class="b_u">-1.6432%</td>`;
                } else if (code.price_OrderExecution < code.price_TC) {
                    output += `<td class="b_d" >${code.price_OrderExecution}</td>
                               <td class="b_d" >${code.kL_OrderExecution}</td>
                               <td class="b_d">-1.6432%</td>`;
                }

                if (code.g1_Sell === code.price_TC) {
                    output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.g1_Sell}">${code.g1_Sell}</td>
                               <td class="b_r" >${code.kL1_Sell}</td>`;
                } else if (code.g1_Sell === code.price_San) {
                    output += `<td class="b_f" >${code.g1_Sell}</td>
                               <td class="b_f" >${code.kL1_Sell}</td>`;
                } else if (code.g1_Sell === code.price_Tran) {
                    output += `<td class="b_c">${code.g1_Sell}</td>
                               <td class="b_c" >${code.kL1_Sell}</td>`;
                } else if (code.g1_Sell > code.price_TC) {
                    output += `<td class="b_u" >${code.g1_Sell}</td>
                               <td class="b_u" >${code.kL1_Sell}</td>`;
                } else if (code.g1_Sell < code.price_TC) {
                    output += `<td class="b_d" >${code.g1_Sell}</td>
                               <td class="b_d" >${code.kL1_Sell}</td>`;
                }

                if (code.g2_Sell === code.price_TC) {
                    output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.g2_Sell}">${code.g2_Sell}</td>
                                <td class="b_r" >${code.kL2_Sell}</td>`;
                } else if (code.g2_Sell === code.price_San) {
                    output += `<td class="b_f" >${code.g2_Sell}</td>
                                <td class="b_f" >${code.kL2_Sell}</td>`;
                } else if (code.g2_Sell === code.price_Tran) {
                    output += `<td class="b_c">${code.g2_Sell}</td>
                                <td class="b_c" >${code.kL2_Sell}</td>`;
                } else if (code.g2_Sell > code.price_TC) {
                    output += `<td class="b_u" >${code.g2_Sell}</td>
                                <td class="b_u" >${code.kL2_Sell}</td>`;
                } else if (code.g2_Sell < code.price_TC) {
                    output += `<td class="b_d" >${code.g2_Sell}</td>
                                <td class="b_d" >${code.kL2_Sell}</td>`;
                }

                if (code.g3_Sell === code.price_TC) {
                    output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.g3_Sell}">${code.g3_Sell}</td>
                               <td class="b_r" >${code.kL3_Sell}</td>`;
                } else if (code.g3_Sell === code.price_San) {
                    output += `<td class="b_f" >${code.g3_Sell}</td>
                                <td class="b_f" >${code.kL3_Sell}</td>`;
                } else if (code.g3_Sell === code.price_Tran) {
                    output += `<td class="b_c">${code.g3_Sell}</td>
                               <td class="b_c" >${code.kL3_Sell}</td>`;
                } else if (code.g3_Sell > code.price_TC) {
                    output += `<td class="b_u" >${code.g3_Sell}</td>
                               <td class="b_u" >${code.kL3_Sell}</td>`;
                } else if (code.g3_Sell < code.price_TC) {
                    output += `<td class="b_d" >${code.g3_Sell}</td>
                               <td class="b_d" >${code.kL3_Sell}</td>`;
                }

            output += `             
                <td  class="g__">${code.totalKL}</td>`;

            if (code.openDoor === code.price_TC) {
                output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.openDoor}">${code.openDoor}</td>`;                          
            } else if (code.openDoor === code.price_San) {
                output += `<td class="b_f" > ${ code.openDoor }</td >`;                               
            } else if (code.openDoor === code.price_Tran) {
                output += `<td class="b_c">${code.openDoor}</td>`;                             
            } else if (code.openDoor > code.price_TC) {
                output += `<td class="b_u" >${code.openDoor}</td>`;
            } else if (code.openDoor < code.price_TC) {
                output += `<td class="b_d" >${code.openDoor}</td>`;
            }

            if (code.tallest === code.price_TC) {
                output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.tallest}">${code.tallest}</td>`;
            } else if (code.tallest === code.price_San) {
                output += `<td class="b_f" > ${code.tallest}</td >`;
            } else if (code.tallest === code.price_Tran) {
                output += `<td class="b_c">${code.tallest}</td>`;
            } else if (code.tallest > code.price_TC) {
                output += `<td class="b_u" >${code.tallest}</td>`;
            } else if (code.tallest < code.price_TC) {
                output += `<td class="b_d" >${code.tallest}</td>`;
            }

            if (code.lowest === code.price_TC) {
                output += `<td class="b_r" onchange="compareData(this, ${code.price_TC})" data-real-time="${code.lowest}">${code.lowest}</td>`;
            } else if (code.lowest === code.price_San) {
                output += `<td class="b_f" > ${code.lowest}</td >`;
            } else if (code.lowest === code.price_Tran) {
                output += `<td class="b_c">${code.lowest}</td>`;
            } else if (code.lowest > code.price_TC) {
                output += `<td class="b_u" >${code.lowest}</td>`;
            } else if (code.lowest < code.price_TC) {
                output += `<td class="b_d" >${code.lowest}</td>`;
            }

            output += `                
                <td class="g__">${code.nnBuy}</td>
                <td class="g__">${code.nnSell}</td>
                <td class="g__">${code.room_Left}</td>
            </tr>`;

            //console.log(code)
            //console.log(output)
        });
        postList.innerHTML = output;
    }

    const url = 'https://localhost:44318/api/Code';
    fetch(`${url}/GetAllCode`)
        .then(res => res.json())
        .then(data => renderCode(data))
//console.log(data)
});

//function compareData(g2, tcValue) {
//    var g2Value = g2.getAttribute("data-real-time");
//    if (g2Value !== tcValue)
//        g2.className = 'b_f';

//    //setTimeout(function () {
//    //    document.getElementById("g2").setAttribute("data-real-time", Math.floor(Math.random() * (43.4 - 44 + 1)) + 43.4);
//    //    document.getElementById("g2").value = "444";
//    //}, 1000);

//}

//window.onload = function () {
//    for (var i = 0; i < 10; i++) {
//        setTimeout(function () {
//            document.getElementById("g2").setAttribute("data-real-time", 444);
//            document.getElementById("g2").value = "444";
//            document.getElementById("g2").trigger('change'); 
//        }, 1000);
//    }
//}


