import React from 'react';
import { connect } from 'react-redux';
import { Input, SubmitButton } from 'root/components';
import { loginChanged, loginSignInStart } from 'root/redux/actionCreators/login';
import * as S from './styled';

const Login = ({
    userName,
    password,
    loginChanged,
    loginSignInStart,
}) => {
    const handleSubmitClick = () => {
        loginSignInStart({ userName, password });
    };

    const handleValueChanged = e => {
        const { value, name } = e.target;
        loginChanged({ userName, password, [name]: value });
    };

    return (<S.Container>
        <S.FormContainer>
            <S.Form>
                <Input onChange={handleValueChanged} name="userName" type="text" value={userName} placeholder="User name" />
                <Input onChange={handleValueChanged} name="password" type="password" value={password} placeholder="Password" />
            </S.Form>
            <SubmitButton onClick={handleSubmitClick} />
        </S.FormContainer>
    </S.Container>);
};


const mapStateToProps = state => ({
    userName: state.login.userName,
    password: state.login.password,
});

const mapDispatchToProps = ({
    loginChanged,
    loginSignInStart,
});

export default connect(
    mapStateToProps,
    mapDispatchToProps,
)(Login);
