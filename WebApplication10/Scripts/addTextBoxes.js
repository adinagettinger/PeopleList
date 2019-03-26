$(() => {
    
    let num = 0;

    $("#addrows").on('click', function () {
        console.log('foo');

        num++;
        $("#addform").append(`<div class="row" style="margin-top:40px">
        <div class="col-md-3">
            <input class="form-control" type="text" name="people[${num}].firstName" placeholder="first name" />
        </div>
        <div class="col-md-3">
            <input class="form-control" type="text" name="people[${num}].lastName" placeholder="last name" />
        </div>
        <div class="col-md-3">
            <input class="form-control" type="text" name="people[${num}].age" placeholder="age" />
        </div>
    </div>`)
    });
});