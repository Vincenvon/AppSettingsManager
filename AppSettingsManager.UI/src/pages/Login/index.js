import React from 'react';
import { SubmitButton, Input } from 'root/components';
import * as S from './styled';

const Login = ({ }) => {
    const handleSubmitClick = () => {

    };

    return (<S.Container>
        <S.FormContainer>
            <S.Form>
                <Input />
                <Input />
            </S.Form>
            <SubmitButton onClick={handleSubmitClick} />
        </S.FormContainer>
    </S.Container>);
};

export default Login;
