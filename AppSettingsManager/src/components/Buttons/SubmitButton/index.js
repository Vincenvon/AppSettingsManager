import React from 'react';
import * as S from './styled';

const SubmitButton = ({ onClick }) => {
    return (
        <S.Button type="button" onClick={onClick}>Submit</S.Button>
    );
};

export default SubmitButton;